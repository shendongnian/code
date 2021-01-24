            foreach(string item in files)
            {
                string fullpath = path + item;
                using (StreamReader reader = new StreamReader(fullpath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        try
                        {
                            float.Parse(line.Split(';')[1]);
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                        string productname = line.Split(';')[0];
                        float price = float.Parse(line.Split(';')[1]);
                        if (!products.Exists(e => e.ProductCode == productname))
                        {
                            products.Add(new Product() { ProductCode = productname , FirstPrice = price });
                        }
                        else
                        {
                            foreach(Product _product in products)
                            {
                                if(_product.ProductCode == productname)
                                {
                                    if(_product.SecondPrice == null)
                                    {
                                        _product.SecondPrice = price;
                                    }
                                    else
                                    {
                                        _product.ThirdPrice = price;
                                    }
                                }
                            }
                        }
                    }
                }
            }
