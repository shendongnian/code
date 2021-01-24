       ITemplateContext ctx = new TemplateContext();
             List<Orders> ProductList = new List<Orders>
       {
            new Orders {OrderId = 1,ProductName="Some name",Quantity =30},
           new Orders {OrderId = 1,ProductName="Some name1",Quantity =30},
           new Orders {OrderId = 1,ProductName="Some name2",Quantity =30}
        };
           
            ctx.DefineLocalVariable("context", ProductList.ToLiquid());
