    public abstract class QuoteBase
    {
             protected void changeQuoteDisplayed() 
             {
                 string s;
                 s = getRandomQuote();
                 LabelText = s;
                // theForm.lblDisplayQuote.Text = s;
              }
              public abstract String LabelText
              {
                       get; set;
              }
     }
     public class EditQuote : QuoteBase
     {
            public override String LabelText
            {
                   get { return lblDisplayQuote.Text; }
                   set { lblDisplayQuote.Text = value; }
            }
      }
