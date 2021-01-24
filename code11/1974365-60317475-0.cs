 <TextBox Name="MiejsceWykonaniaNadgodzinText" Width="300"  Height="50" FontSize="15">              
                <Validation.ErrorTemplate>
                    <ControlTemplate>
                        <StackPanel>
                            <!-- Placeholder for the TextBox itself -->
                            <AdornedElementPlaceholder x:Name="textBox"/>
                            <TextBlock Text="{Binding [0].ErrorContent}" Foreground="Red"/>
                        </StackPanel>
                    </ControlTemplate>
                </Validation.ErrorTemplate>
                
            </TextBox>
and this is my Nadgodziny.cs
private string miejsceWykonaniaNadgodzin;
      public string MiejsceWykonaniaNadgodzin
        {
            get => miejsceWykonaniaNadgodzin;
            set
            {
                this.miejsceWykonaniaNadgodzin = value;//"aaa";
                OnPropertyChanged(nameof(MiejsceWykonaniaNadgodzin));
            }
        }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string miejsceWykonaniaNadgodzin = null)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(miejsceWykonaniaNadgodzin));
        }
    ```
                                                                                                        
