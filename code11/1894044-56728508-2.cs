    public class BoolStateParameter : StateParameter<bool>
    { }
    public class TextStateParameter : StateParameter<string>
    { }
    public class ChoiceStateParameter : StateParameter<object>
    {
        public Array Choices { get; set; }
    }
The _ChoiceStateParameter_ class declares an additional property which is used to hold the array with the possible values to choose from for a particular state parameter. (Like the _StateParameter&lt;T&gt;.State_ above, this property is meant to be set only once, and the reason i gave it a setter here is to keep the code in my answer relatively short and simple.)
Aside from the _ChoiceStateParameter_ class, no other class has any declaration in it. Why would we need _BoolStateParameter/TextStateParameter_ if we could use _StateParameter&lt;bool&gt;/StateParameter&lt;string&gt;_ directly, you ask? That's a good question. If we wouldn't have to deal with XAML, we could easily use _StateParameter&lt;bool&gt;/StateParameter&lt;string&gt;_ directly (assuming _StateParameter&lt;T&gt; was not an abstract class). However, attempting to refer to generic types from within XAML markup is something between quite painful and outright impossible. Thus, the non-generic concrete state parameter classes _BoolStateParameter_, _TextStateParameter_ and _ChoiceStateParameter_ have been defined.
Oh, and before we forget, since we have declared the common state parameter base type as an interface named `IStateParameter`, the type parameter of the `StateParametersList` property in the viewmodel has to be adjusted accordingly (and its backing field, too, of course):
    public ObservableCollection<IStateParameter> StateParametersList { get ..... set ..... }
With this done, we have finished the part on the C# code side, and we move on to the DataGrid.
<br>
**3. UI / XAML**
Since the different state parameter categories demand different interaction elements (CheckBoxes, TextBoxes, ComboBoxes), we will attempt to leverage DataTemplates to define how each of those state parameter categories should be represented inside the DataGrid cells.
Now it will also become obvious why we made the effort to define those categories and declared different state parameter types for each of them. Because DataTemplates can be assosiacted with a specific type. And we are now going to define those DataTemplates for each the `BoolStateParameter`, `TextStateParameter` and `ChoiceStateParameter` type.
The DataTemplates will be placed within the DataGrid, as part of the DataGrid's resource dictionary:
    <DataGrid Name="dataGridView" ItemsSource="{Binding Path=StateParametersList}" ... >
		<DataGrid.Resources>
			<DataTemplate DataType="{x:Type local:BoolStateParameter}">
				<CheckBox IsChecked="{Binding Value, UpdateSourceTrigger=PropertyChanged}" />
			</DataTemplate>
			<DataTemplate DataType="{x:Type local:TextStateParameter}">
				<TextBox Text="{Binding Value, UpdateSourceTrigger=PropertyChanged}" />
			</DataTemplate>
			<DataTemplate DataType="{x:Type local:ChoiceStateParameter}">
				<ComboBox ItemsSource="{Binding Choices}" SelectedItem="{Binding Value, UpdateSourceTrigger=PropertyChanged}" />
			</DataTemplate>
		</DataGrid.Resources>
(_Note: You might need to adapt the `local:` namespace i used here or exchange it with a XML namespace that is mapped to the C# namespace in which you declare the state parameter classes._)
Next step is to make the _DataGridTemplateColumn_ pick the appropriate DataTemplate depending on the actual type of state parameter it is dealing with in a given column cell. However, _DataGridTemplateColumn_ cannot pick a DataTemplate from the resource dicationary itself, nor does the _DataGrid_ control does it on behalf of _DataGridTemplateColumn_. So, what now?
Fortunately, there are UI elements in WPF which present some value/object using a DataTemplate from a resource dictionary, with the DataTemplate being choosen based on the type of the value/object. One such a UI element is [`ContentPresenter`][3], which we will use in the _DataGridTemplateColumn_:
		<DataGrid.Columns>
			<DataGridTextColumn Binding="{Binding State}"/>
			<DataGridTemplateColumn Width="*">
				<DataGridTemplateColumn.CellTemplate>
					<DataTemplate>
						<ContentPresenter Content="{Binding}" />
					</DataTemplate>
				</DataGridTemplateColumn.CellTemplate>
			</DataGridTemplateColumn>
		</DataGrid.Columns>
    </DataGrid>
And that's it. With a small expansion of the underlying data model (the state parameter classes), the XAML problems simply vanished (or so i hope).
<br>
**4. Demo dataset**
A quick test dataset to demonstrate the code in action (using randomly picked enum types as examples):
	StateParametersList = new ObservableCollection<IStateParameter>
	{
		new BoolStateParameter {State = "Bool1", Value = false },
		new ChoiceStateParameter {State = "Enum FileShare", Value = System.IO.FileShare.ReadWrite, Choices = Enum.GetValues(typeof(System.IO.FileShare)) },
		new TextStateParameter {State = "Text1", Value = "Hello" },
		new BoolStateParameter {State = "Bool2", Value = true },
		new ChoiceStateParameter {State = "Enum ConsoleKey", Value = System.ConsoleKey.Backspace, Choices = Enum.GetValues(typeof(System.ConsoleKey)) },
		new TextStateParameter {State = "Text2", Value = "World" }
	};
It will look like this:
[![enter image description here][4]][4]
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged
  [2]: https://stackoverflow.com/questions/143405/c-sharp-interfaces-implicit-implementation-versus-explicit-implementation
  [3]: https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.contentpresenter
  [4]: https://i.stack.imgur.com/n6a5U.png
