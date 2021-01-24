    protected override void OnResume()
      {
          base.OnResume();
          StartMyRequestService();
      }
    public void StartMyRequestService()
      {
          var serviceToStart = new Intent(this, typeof(MyService));
          StartService(serviceToStart);
      }
