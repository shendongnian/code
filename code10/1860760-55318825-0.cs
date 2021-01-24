        public class PersistentObject
        {
            [XmlAttribute("Name")]
            public string Name { get; set; }
            public string TableName { get; set; }
            public string Description { get; set; }
            [XmlArray("Fields")]
            [XmlArrayItem("Field")]
            List<FieldSchemaXml> Fields { get; set; }
        }
        public class FieldSchemaXml
        {
            [XmlAttribute("Name")]
            public string Name { get; set; }
            public string DBType { get; set; }
            public string Precision { get; set; }
            public string Scale { get; set; }
            public string FillType { get; set; }
            public string IsNullable { get; set; }
            public string IsReadOnly { get; set; }
            public string AllowOverwrite { get; set; }
            public string IsPrimaryKey { get; set; }
            public string IsDeltaField { get; set; }
            public string IsIndexed { get; set; }
            public string IsTransient { get; set; }
            public string IsUnique { get; set; }
            public string OverrideFormatting { get; set; }
            public string IsLockable { get; set; }
            public string Direction { get; set; }
            public string ValueSetByDatabase { get; set; }
            public string FormatScale { get; set; }
            public string FormatMask { get; set; }
            public string NegativeFormatting { get; set; }
            public string Group { get; set; }
            public string AggregateFunction { get; set; }
            public string IsExcludedFromCopy { get; set; }
            public string IsExpression { get; set; }
            public string FriendlyName { get; set; }
            public string IsBrowsable { get; set; }
            public string IsQueryable { get; set; }
            public string IsEnumeration { get; set; }
            public string IsAddInPrimaryKey { get; set; }
            public string AddInTableName { get; set; }
            public string AddInRelationField { get; set; }
            public string IsMember { get; set; }
            public string IsExcludedFromReset { get; set; }
        }
