    <ListBox x:Name="lb">
        <ListBox.Resources>
            <DataTemplate DataType="{x:Type local:MyClass}">
                <TextBlock>My Class...</TextBlock>
            </DataTemplate>
            <DataTemplate DataType="{x:Type local:MyClass2}">
                <TextBlock>My Class 2...</TextBlock>
            </DataTemplate>
        </ListBox.Resources>
    </ListBox>
----------
    public interface MyInterface { }
    public class MyClass : MyInterface { }
    public class MyClass2 : MyInterface { }
    public class MyClass3 : MyInterface { }
    ...
    lb.ItemsSource = new List<MyInterface> { new MyClass(), new MyClass(), new MyClass2(), new MyClass3() };
