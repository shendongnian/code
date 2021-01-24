public class Form1 
{
   public static bool form2closed = false;
   ...
   public void ChangeColours()
   {
       while (!form2closed) { }
       menustrip1.backcolour = ...
   }
   ...
}
public class Form2
{
   public Form2
   {
       ...
       this.FormClosing += Form2_FormClosing;
   }
   private void Form2_FormClosing(object sender, FormClosingEventArgs e)
   {
       Form1.form2closed = true;
   }
   ...
}
Where ... is your existing code.
