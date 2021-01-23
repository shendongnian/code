        public CodeGenerationTools() {
            _textTransformation = DynamicTextTransformation.Create(this);
            _code = new CSharpCodeProvider();
            _ef = new MetadataTools(_textTransformation);
            FullyQualifySystemTypes = false;
            CamelCaseFields = true;
        }
