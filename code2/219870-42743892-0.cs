    using CsQuery; //get CsQuery from nuget packages
    path = textBox1.Text;
            var dom = CQ.CreateFromUrl(path);
            var divContent = dom.Select("#priceblock_ourprice").Text();
            //priceblock_ourprice is an id of span where price is written
            label1.Text = divContent.ToString();
