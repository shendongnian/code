            services.AddSwaggerGen(c =>
            {
				... the rest of your configuration
				
				// REMOVE THIS to use Integers for Enums
                // c.DescribeAllEnumsAsStrings();
				// add enum generators based on whichever code generators you decide
                c.SchemaFilter<NSwagEnumExtensionSchemaFilter>();
                c.SchemaFilter<EnumFilter>();
            });
