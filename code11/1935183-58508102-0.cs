    rssSubNode = rssNode.SelectSingleNode("joblisting:categories", nsmgr);
                    if (rssSubNode.HasChildNodes)
                    {
                        rssSubNode = rssSubNode.SelectSingleNode("joblisting:category", nsmgr);
                        rssSubNode = rssSubNode.SelectSingleNode("Category");
                        string category = rssSubNode.InnerXml;
                        string Category = "<category>" + category + "</category>";
                        sb.AppendLine(Category);
                    }
