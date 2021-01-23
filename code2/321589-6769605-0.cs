    <ProgressBar>
        <ProgressBar.Resources>
            <src:DoubleToVisibilityConverter x:Key="_doubleToVisibilityConverter" />
        </ProgressBar.Resources>
        <ProgressBar.Visibility>
            <Binding
                RelativeSource="{RelativeSource Self}"
                Path="Value"
                Converter="{StaticResource _doubleToVisibilityConverter}"
            />
        </ProgressBar.Visibility>
    </ProgressBar>
