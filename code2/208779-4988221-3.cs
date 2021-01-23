    <?xml version="1.0" encoding="utf-8" ?>
    <CodeSnippets  xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
    	<CodeSnippet Format="1.0.0">
    		<Header>
    			<Title>Value Converter Stub (Light)</Title>
    			<Shortcut>vcl</Shortcut>
    			<Description>Code snippet for a light value converter stub</Description>
    			<Author>H.B.</Author>
    			<SnippetTypes>
    				<SnippetType>Expansion</SnippetType>
    			</SnippetTypes>
    		</Header>
    		<Snippet>
    			<Declarations>
				<Literal>
					<ID>convertername</ID>
					<ToolTip>Name of the converter.</ToolTip>
					<Default>My</Default>
				</Literal>
    			</Declarations>
    			<Code Language="csharp">
    				<![CDATA[public class $convertername$Converter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		$end$
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		throw new NotSupportedException();
    	}
    }]]>
    			</Code>
    		</Snippet>
    	</CodeSnippet>
    </CodeSnippets>
