    public interface ICommand {
      void Execute();
    }
    
    public class BankAccountWebServiceCall: ICommand(){
      
      string name;
      int accountNo;
    
      public BankAccountWebServiceCall(string name, int accountNo) {
        this.name= param1;
        this.accountNo= accountNo;
      }
    
      //ICommand implementation
      public void Execute() {
        SomeWebService.Call(name, accountNo);
      }
    }
    
    public class WebServiceCaller {
      public void CallService(ICommand command) {
        try {
          command.Execute();
        } catch (SomeBusinessException ex) {
          //handle exception
        }
      }
    }
    
    public class WebServiceCallerTest {
      public static void CallServiceTest() {
        new WebServerCaller().CallService(new TwoParameterwebServiceCall("Igor", 12345));
      }
    }
