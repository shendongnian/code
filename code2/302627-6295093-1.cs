    public class MyScript
    {
      // ...
      protected void forLoop(List<String> Params; MyDelegateType MyDelegate)
      {
        int HowManyTimes = Convert.ToInt16(Params[0]);
        for (int k=1; k == HowManyTimes; k++) 
        {
           MyDelegate();
        } 
      }
      protected void interpret
         (String Instruction, List<String> Params; MyDelegateType MyDelegate)
      {
        if (Instruction == "declare")
        {
          this.declare(Params);
        }
        else if (Instruction == "set")
        {
          this.set(Params);
        }
        else if (Instruction == "for")
        {
          this.forLoop(Params, MyDelegate);
        }
      }
    } // class
