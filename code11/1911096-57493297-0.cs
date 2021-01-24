            base.OnSizeAllocated(width, height);
            if(width > height)
            {
                _ = GoToPageAsync();
            }
        }
        private  async Task GoToPageAsync()
        {
            await Navigation.PushAsync(new TestPage());
        }
