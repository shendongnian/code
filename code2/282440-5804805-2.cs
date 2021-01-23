    using umbraco.presentation.nodeFactory;
        
    public string CreateSitemap()
    {
        var temp = "<ul>" + sitemap(-1) + "</ul>";
        return temp;
    }
    
    public string sitemap(int nodeID)
    {
        var rootNode = new umbraco.presentation.nodeFactory.Node(nodeID);
        string sitemapstring = "<li><a href=" + rootNode.Id + ">" + rootNode.Name + "</a></li>";
        if(rootNode.Children.Count>0)
        {
            sitemapstring+="<ul>";
            foreach(Node node in rootNode.Children)
            {
                sitemapstring += sitemap(node.Id);
            }
             sitemapstring+="</ul>";
        }
        return sitemapstring;
    
    }
