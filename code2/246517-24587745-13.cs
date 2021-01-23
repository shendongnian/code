    public class CustomFontFactory : FontFactoryImp
    {
    	public const Single DEFAULT_FONT_SIZE = 12;
    	public const Int32 DEFAULT_FONT_STYLE = 0;
    	public static readonly BaseColor DEFAULT_FONT_COLOR = BaseColor.BLACK;
    
    	public String DefaultFontPath { get; private set; }
    	public String DefaultFontEncoding { get; private set; }
    	public Boolean DefaultFontEmbedding { get; private set; }
    	public Single DefaultFontSize { get; private set; }
    	public Int32 DefaultFontStyle { get; private set; }
    	public BaseColor DefaultFontColor { get; private set; }
    
    	public Boolean ReplaceEncodingWithDefault { get; set; }
    	public Boolean ReplaceEmbeddingWithDefault { get; set; }
    	public Boolean ReplaceFontWithDefault { get; set; }
    	public Boolean ReplaceSizeWithDefault { get; set; }
    	public Boolean ReplaceStyleWithDefault { get; set; }
    	public Boolean ReplaceColorWithDefault { get; set; }
    
    	public BaseFont DefaultBaseFont { get; protected set; }
    
    	public CustomFontFactory(
    		String defaultFontFilePath,
    		String defaultFontEncoding = BaseFont.IDENTITY_H,
    		Boolean defaultFontEmbedding = BaseFont.EMBEDDED,
    		Single? defaultFontSize = null,
    		Int32? defaultFontStyle = null,
    		BaseColor defaultFontColor = null,
    		Boolean automaticalySetReplacementForNullables = true)
    	{
    		//set default font properties
    		DefaultFontPath =  defaultFontFilePath;
    		DefaultFontEncoding = defaultFontEncoding;
    		DefaultFontEmbedding = defaultFontEmbedding;
    		DefaultFontColor = defaultFontColor == null
    			? DEFAULT_FONT_COLOR
    			: defaultFontColor;
    		DefaultFontSize = defaultFontSize.HasValue
    			? defaultFontSize.Value
    			: DEFAULT_FONT_SIZE;
    		DefaultFontStyle = defaultFontStyle.HasValue
    			? defaultFontStyle.Value
    			: DEFAULT_FONT_STYLE;
    
    		//set default replacement options
    		ReplaceFontWithDefault = false;
    		ReplaceEncodingWithDefault = true;
    		ReplaceEmbeddingWithDefault = false;
    
    		if (automaticalySetReplacementForNullables)
    		{
    			ReplaceSizeWithDefault = defaultFontSize.HasValue;
    			ReplaceStyleWithDefault = defaultFontStyle.HasValue;
    			ReplaceColorWithDefault = defaultFontColor != null;
    		}
    
    		//define default font
    		DefaultBaseFont = BaseFont.CreateFont(DefaultFontPath, DefaultFontEncoding, DefaultFontEmbedding);
            
    		//register system fonts
    		FontFactory.RegisterDirectories();
    	}
    
    	protected Font GetBaseFont(Single size, Int32 style, BaseColor color)
    	{
    		var baseFont = new Font(DefaultBaseFont, size, style, color);
    
    		return baseFont;
    	}
    
    	public override Font GetFont(String fontname, String encoding, Boolean embedded, Single size, Int32 style, BaseColor color, Boolean cached)
    	{
    		//eventually replace expected font properties
    		size = ReplaceSizeWithDefault
    			? DefaultFontSize
    			: size;
    		style = ReplaceStyleWithDefault
    			? DefaultFontStyle
    			: style;
    		encoding = ReplaceEncodingWithDefault
    			? DefaultFontEncoding
    			: encoding;
    		embedded = ReplaceEmbeddingWithDefault
    			? DefaultFontEmbedding
    			: embedded;
            
    		//get font
    		Font font = null;
    		if (ReplaceFontWithDefault)
    		{
    			font = GetBaseFont(
    				size,
    				style,
    				color);
    		}
    		else
    		{
    			font = FontFactory.GetFont(
    				fontname,
    				encoding,
    				embedded,
    				size,
    				style,
    				color,
    				cached);
    
    			if (font.BaseFont == null)
    				font = GetBaseFont(
    					size,
    					style,
    					color);
    		}
    
    		return font;
    	}
    }
