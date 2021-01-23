    [MetadataType(typeof(Foobar.Metadata))]
    [Serializable]
    public partial class Foobar
    {
        private sealed class Metadata
        {
            [Required]
            [MinLength(10)]
            public object Name { get; set; }
        }
		// Other stuff here
    }
