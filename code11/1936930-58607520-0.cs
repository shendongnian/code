    public void Func()
    {
        vkParams.TwoFactor = () =>
        {
            return Dispatcher.Invoke(() =>
            {                    
                var two = new TwoFactor();
                two.ShowDialog();
                return two.Data;
            }));
        }
    } 
    private async void Auth()
    {
        vkParams.Login = t_login.Text;
        vkParams.Password = t_pass.Text;
        await vkApi.AuthorizeAsync(vkParams);
    }
