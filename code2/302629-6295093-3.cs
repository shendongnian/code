    public class MyScriptInterpreter
    {
      // ...
      protected void forLoop(List<String> Params; List<String> Block)
      {
        int HowManyTimes = Convert.ToInt16(Params[0]);
        for (int k=1; k == HowManyTimes; k++) 
        {
           interpretBlock(Block);
        } 
      }
      protected void interpretBlock(List<String> Block)
      {
        foreach(String eachInstruction in Block)
        {
           interpret(eachInstruction);
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
