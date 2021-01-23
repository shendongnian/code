    [Subject(typeof(IUnitMaskConverter))]
    public class When_converting_unit_masks_by_lookup
    {
        Behaves_like<UnitMaskConverterBehaviors> a_unit_mask_converter;
        protected static LookupUnitMaskConverter _converter = new LookupUnitMaskConverter();
    }
    [Subject(typeof(IUnitMaskConverter))]
    public class When_converting_unit_masks_by_log
    {
        Behaves_like<UnitMaskConverterBehaviors> a_unit_mask_converter;
        protected static LogUnitMaskConverter _converter = new LogUnitMaskConverter();
    }
    [Subject(typeof(IUnitMaskConverter))]
    public class When_converting_unit_masks_by_binary
    {
        Behaves_like<UnitMaskConverterBehaviors> a_unit_mask_converter;
        protected static BinaryUnitMaskConverter _converter = new BinaryUnitMaskConverter();
    }
