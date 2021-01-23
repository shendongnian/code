    public partial class loginResponse {
   
     [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
     public loginReturn @return;
        
     public loginResponse() {
     }
        
     public loginResponse(loginReturn @return) {
       this.@return = @return;
      }
    }
