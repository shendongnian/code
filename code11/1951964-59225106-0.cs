			foreach (var item in ruleGroupList)
            {
                if (item.Descendants().Attributes("ruleAttrib").Count() != 0)
                {
                    List<XAttribute> ruleAttriblist  = item.Descendants().Attributes("ruleAttrib").ToList();
                    
					foreach (var item in ruleAttriblist)
                    {
                        Console.WriteLine(item.Value);
                    }
                }
            }
            Console.ReadLine();
