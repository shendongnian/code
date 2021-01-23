    public class Presenter
    {
        private readonly IForm1 form1;
        private readonly IModel model;
        public Presenter(IForm1 form1, IModel model)
        {
            this.form1 = form1;
            this.model = model;
            this.form1.Button1Clicked += this.Form1Button1Clicked;
            this.model.Completed += this.ModelCompleted;
        }
        private void ModelCompleted(object sender, SampleEventArgs e)
        {
            this.form1.Update(e.Data);
        }
        private void Form1Button1Clicked(object sender, EventArgs e)
        {
            this.model.LongRunningTask();
        }
    }
