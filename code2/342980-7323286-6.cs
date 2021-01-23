    public readonly static DependencyProperty QuestionsSourceProperty =
        DependencyProperty.Register("QuestionsSource",
            typeof(IEnumerable),
            typeof(FormQuestionReportViewer), 
            new PropertyMetadata(null));
     public IEnumerable QuestionsSource
     {
        get { return GetValue(QuestionsSourceProperty) as IEnumerable; }
        set { SetValue(QuestionsSourceProperty, value); }
     }
