&lt;ItemsControl x:Name="level1Lister" ItemsSource={Binding MyLevel1List}&gt;
  &lt;ItemsControl.ItemTemplate&gt;
    &lt;DataTemplate&gt;
      &lt;Button Content={Binding MyLevel2Property}
              Command={Binding ElementName=level1Lister, Path=DataContext.MyLevel1Command}
              CommandParameter={Binding MyLevel2Property}&gt;
      &lt;/Button&gt;
    &lt;DataTemplate&gt;
  &lt;ItemsControl.ItemTemplate&gt;
&lt;/ItemsControl&gt;
