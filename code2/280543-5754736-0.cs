        [Table(Name="Articles")]
        public class Article
        {        
            [HiddenInput(DisplayValue=false)]
            [Column(IsPrimaryKey=true, IsDbGenerated=true,AutoSync=AutoSync.OnInsert)]
            public int ArticleId { get; set; }
            [Column]
            internal int ArticleCategoryId { get; set; }
            internal EntityRef<ArticleCategories> _ArticleCategoryId;
            //[Column(AutoSync = AutoSync.OnInsert, Name = "ArticleCategoryId")]
            [System.Data.Linq.Mapping.Association(ThisKey="ArticleCategoryId", Storage="_ArticleCategoryId")]
            public ArticleCategories ArticleCategory
            {
                get
                {
                    return _ArticleCategoryId.Entity;
                }
                set
                {
                    ArticleCategoryId = value.ArticleCategoryId;
                    _ArticleCategoryId.Entity = value;                
                }
            }
            [Column] public string Label { get; set; }
            [DataType(DataType.MultilineText)]
            [Column] public string Text { get; set; }
            [Required(ErrorMessage = "Musíte vybrat kategorii článku.")]
            [DataType(DataType.DateTime)]
            [Column] public DateTime Created { get; set; }
    }
