    <StackPanel>
        <TextBox Text="{Binding TextProperty, Mode=OneWayToSource, UpdateSourceTrigger=PropertyChanged}"/>
        <Button/>
    </StackPanel>
		private string m_textProperty;
		public string TextProperty
		{
			get
			{
				return "Should not be used in OneWayToSource Binding";
			}
			set
			{
				m_textProperty = value;
			}
		}
