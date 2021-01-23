    public class test : Form
    {
      public test()
      {
        Thread t = new Thread(start);
        t.Start();
      }
      public void start()
      {
        LoadCompleteEvent();
      }
      public void LoadComplete() //fired by LoadCompleteEvent();
      {
        if(this.InvokeIsRequired)
        {
          //do invoke
          //and return
        }
        comboBoxEditBrand.Properties.Items.Clear();
        comboBoxEditBrand.Properties.Items.AddRange(ListOfStuff.ToArray());
      }
      public void comboBoxEditBrand_SelectedItemChanged(object sender, eventargs e) // fired as control is changed
      {
        //error here!!
        if(comboBoxEditBrand.SelectedItem == SomeBrandItem) //<- this is where the error is thrown!! check for null first!
        {
          //do something
        }
      }
    }
