    public partial class ThisAddIn
    {
       private CustomTaskPane taskPane; 
       internal CustomTaskPane TaskPane
       {
          get
          {
             return this.taskPane;
          }
       }
