     public class WebPage
    {
        public string Href { get; set; }
        public string PageTitle { get; set; }
        public List<WebPage> LinksInPage { get; set; }
    }
    public class Root
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public List<WebPage> WebPages { get; set; }
    }
        <HierarchicalDataTemplate DataType="{x:Type data:Root}"
                                  ItemsSource="{Binding Path=WebPages}">
                    <TextBlock Text="{Binding Title}"></TextBlock>
        </HierarchicalDataTemplate>
       
        <HierarchicalDataTemplate DataType="{x:Type data:WebPage}"
                                  ItemsSource="{Binding Path=LinksInPage}">
                    <TextBlock Text="{Binding PageTitle}"></TextBlock>
        </HierarchicalDataTemplate>
