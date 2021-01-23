                  //This collection will contain property collections for each node
                  System.Collections.ObjectModel.Collection<SvnPropertyListEventArgs> proplist;
    
                  //This is where we can specify arguments to svn proplist
                  SvnPropertyListArgs args = new SvnPropertyListArgs();
    
                  args.Depth = SvnDepth.Infinity;
    
                  //This method is what executes svn proplist
                  client.GetPropertyList(targetSource, args, out proplist);
    
                  //Each SvnPropertyListEventArgs represents the prop. set for a node
                  foreach (SvnPropertyListEventArgs node in proplist)
                  {
                      //Each SvnPropertyValue represents a single name/value property pair
                      foreach (SvnPropertyValue propVal in node.Properties)
                      {
                          items.Items.Add(node.Path);
                      }
                  }
    
                  int total_items = items.Items.Count;
                  long totalsize = 0;
                  for (int i = 0; i < total_items; i++)
                  {
                      client.GetInfo(new Uri(items.Items[i].ToString()), out info);
                      totalsize = totalsize + info.RepositorySize;
    
                  }
                  MessageBox.Show(string.Format("The total size of {0} is {1}", targetSource, totalsize));
