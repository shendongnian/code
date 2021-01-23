        class MockClass
        {
            public decimal Fee { get; set; }
            [FeeTimeUnitValidator(otherPropertyName:"Fee", minValue:1, maxValue:12)]
            public int attributeUnderTest { get; set; }
            public int badOtherProperty { get; set; }
            [FeeTimeUnitValidator(otherPropertyName: "badOtherProperty", minValue: 1, maxValue: 12)]
            public int badAttributeUnderTest { get; set; }
            [FeeTimeUnitValidator(otherPropertyName: "NotFoundAttribute", minValue: 1, maxValue: 12)]
            public int nameNotFoundAttribute { get; set; }
        }
