      // Let's assume that this code is run inside of the calling service.
      var winIdentity = ServiceSecurityContext.Current.WindowsIdentity;
      using (var impContext = winIdentity.Impersonate())
      {
        // So this would be the service call that is failing otherwise.
        return MyService.MyServiceCall();
      }
