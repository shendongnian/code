     public async void MethodAsync()
        {
            var result = await SendAsync();
            DoSomething(result);
        }
