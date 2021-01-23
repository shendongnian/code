    <?xml version="1.0" encoding="utf-8"?>
    <CodeSnippet Format="1.0.0" xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
      <Header>
        <Title>ObservableProperty</Title>
        <Author>Scott Austen</Author>
        <Shortcut>#ObsProp</Shortcut>
        <Description>Inserts property definition with private backing field, calling RaisePropertyChanged</Description>
        <SnippetTypes>
          <SnippetType>Expansion</SnippetType>
        </SnippetTypes>
      </Header>
      <Snippet>
        <Declarations>
          <Literal>
            <ID>Type</ID>
            <Default>Type</Default>
          </Literal>
          <Literal>
            <ID>PropertyName</ID>
            <Default>P</Default>
          </Literal>
        </Declarations>
        <Code Language="CSharp">
          <![CDATA[public $Type$ $PropertyName$
          {
            get { return _$PropertyName$; }
            set
            {
              _$PropertyName$ = value;          
              OnPropertyChanged("$PropertyName$");
            }
          }
          
          private $Type$ _$PropertyName$;]]>
        </Code>
      </Snippet>
    </CodeSnippet>
