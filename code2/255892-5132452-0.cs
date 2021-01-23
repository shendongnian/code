                node = hd.DocumentNode.SelectSingleNode("//*[contains(text(),'" + searchData + "')]"); //Find the desired Node.
                while (node.ParentNode.Name != "div") //Move up till you find a encapsulating Div node.
                {
                    node = node.ParentNode;
                    Console.WriteLine(node.InnerText);
                }
                Body = node.InnerText;
                
            }`
