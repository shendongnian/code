        class Program
       {
         static void Main(string[] args)
        {
         string DATA_VALUE = "Not Set Yet";
         Data_Picker_Form D_P_T = new Data_Picker_Form(DATA_VALUE);
         D_P_T.ShowDialog();
         DATA_VALUE = D_P_T.Data_in_new;
         Console.WriteLine("Value is {0}", DATA_VALUE);
        Console.ReadKey();
       }
      }
