    <?xml version="1.0"?>
    <CodeSnippets xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
      <CodeSnippet Format="1.0.0">
        <Header>
          <SnippetTypes>
            <SnippetType>Expansion</SnippetType>
          </SnippetTypes>
          <Title>propn (Creates a notifying property)</Title>
          <Shortcut>propn</Shortcut>
          <Description>This snippet helps implementing INotifyPropertyChanged by creating a property with backing store. The settter calls OnPropertyChanged if the value changes. Use the "notify" code snippet in order to implement INotifyPropertyChanged.</Description>
          <Author>Olivier Jacot-Descombes</Author>
        </Header>
        <Snippet>
          <Declarations>
            <Literal Editable="false">
              <ID>classname</ID>
              <ToolTip>Name of class</ToolTip>
              <Default>ClassNamePlaceholder</Default>
              <Function>ClassName()</Function>
            </Literal>
            <Literal Editable="true">
              <ID>NameOfProperty</ID>
              <ToolTip>
              </ToolTip>
              <Default>MyProp</Default>
              <Function>
              </Function>
            </Literal>
            <Literal Editable="true">
              <ID>Type</ID>
              <ToolTip>
              </ToolTip>
              <Default>int</Default>
              <Function>
              </Function>
            </Literal>
          </Declarations>
          <Code Language="csharp"><![CDATA[private $Type$ _$NameOfProperty$;
    public $Type$ $NameOfProperty$
    {
    	get { return _$NameOfProperty$; }
    	set
    	{
    		if (_$NameOfProperty$ != value) {
    			_$NameOfProperty$ = value;
    			OnPropertyChanged("$NameOfProperty$");
    		}
    	}
    }
    ]]></Code>
        </Snippet>
      </CodeSnippet>
    </CodeSnippets>
