    <SearchBar>
                <SearchBar.Behaviors>
                    <behaviour:EventToCommandBehavior EventName="TextChanged" Command=" {Binding TextChangedCommand}" />
                </SearchBar.Behaviors>
    </SearchBar>
      public ICommand TextChangedCommand => new Command((o) =>
            {
                if (o is TextChangedEventArgs text)
                {
                //do some works
                }
            });
