            this.LoginCommand = ReactiveCommand.CreateFromTask(
                async execute =>
                {
                    var loginSuccessful = await this.loginService.Login(this.Username, this.Password);
                    if (loginSuccessful)
                    {
                        this.HostScreen.Router.NavigateBack.Execute().Subscribe();
                    }
                }, canExecuteLogin);
The above code is navigating back on successful login.  I think you mean to use `Router.Navigate.Execute(new MainPageViewModel()).Subscribe();`
