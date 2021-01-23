            XElement x = XElement.Parse(xml);
            
            ReplaceNodesWithContent(x, "a");
            string res = x.ToString();
            //            res == @"<root>
            //                      <items>
            //                        <item>inner</item>
            //                        <item>
            //                          <subitem>another one</subitem>
            //                        </item>
            //                      </items>
            //                    </root>"
        }
        
