    <?xml version="1.0" encoding="utf-8" ?>
    <CodeSnippets  xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
    	<CodeSnippet Format="1.0.0">
    		<Header>
    			<Title>Value Converter Stub</Title>
    			<Shortcut>vc</Shortcut>
    			<Description>Code snippet for a value converter stub</Description>
    			<Author>H.B.</Author>
    			<SnippetTypes>
    				<SnippetType>Expansion</SnippetType>
    			</SnippetTypes>
    		</Header>
    		<Snippet>
    			<Declarations>
    				<Literal>
    					<ID>from</ID>
    					<ToolTip>The source type.</ToolTip>
    					<Default>object</Default>
    				</Literal>
    				<Literal>
    					<ID>to</ID>
    					<ToolTip>The target type.</ToolTip>
    					<Default>object</Default>
    				</Literal>
    				<Literal>
    					<ID>convertername</ID>
    					<ToolTip>Name of the converter.</ToolTip>
    					<Default>My</Default>
    				</Literal>
    			</Declarations>
    			<Code Language="csharp">
    				<![CDATA[[ValueConversion(typeof($from$), typeof($to$))]
    public class $convertername$Converter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		$from$ input = ($from$)value;
    		$to$ output;
    		
    		throw new NotImplementedException();
    		
    		return output;
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		$to$ input = ($to$)value;
    		$from$ output;
    		
    		throw new NotImplementedException();
    		
    		return output;
    	}
    }]]>
    			</Code>
    		</Snippet>
    	</CodeSnippet>
    </CodeSnippets>
