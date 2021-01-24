c#
public static string Hash(string input)
{
    var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input));
    return string.Concat(hash.Select(b => b.ToString("x2")));
}
public static void GetAllProductsFromIndexes_AndPutInDB(List<IndexModel> indexes, ProductContext context)
{
    BlockingCollection<IndexModel> inputQueue = CreateInputQueue(indexes);
    BlockingCollection<Product> productsQueue = new BlockingCollection<Product>(500);
    var consumer = Task.Run(() =>
    {
        foreach (Product readyProduct in productsQueue.GetConsumingEnumerable())
        {
            InsertProductInDB(readyProduct, context);
        }
    });
    var producers = Enumerable.Range(0, 25)
        .Select(_ => Task.Run(() =>
        {
            foreach (IndexModel index in inputQueue.GetConsumingEnumerable())
            {
                Product product = new Product();
                byte[] unconvertedByteArray;
                string xml;
                string url = @"https://data.Icecat.biz/export/freexml.int/en/";
                unconvertedByteArray = DownloadIcecatFile(index.IndexNumber.ToString() + ".xml", url);
                xml = Encoding.UTF8.GetString(unconvertedByteArray);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                GetProductDetails(product, xmlDoc, index);
                XmlNodeList nodeList = (xmlDoc.SelectNodes("ICECAT-interface/Product/ProductFeature"));
                product.FeaturesLink = GetProductFeatures(product, nodeList);
                nodeList = (xmlDoc.SelectNodes("ICECAT-interface/Product/ProductGallery/ProductPicture"));
                product.Images = GetProductImages(nodeList);
                product.Code= Hash(xml);
                productsQueue.Add(product);
            }
        })).ToArray();
    Task.WaitAll(producers);
    productsQueue.CompleteAdding();
    consumer.Wait();
}
