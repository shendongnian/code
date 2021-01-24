        [JSInvokable]
        public async Task GenerateImageData(string data)
        {
            System.Console.WriteLine( "Receiving"  );
            ImageBase64.Add(data);
            await Task.Delay(1);
            StateHasChanged();
            System.Console.WriteLine( "Received"  );
        }
