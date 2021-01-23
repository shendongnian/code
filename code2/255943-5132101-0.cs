    [Association(
        Name="FK_OtherImages_Images",
        Storage="_OtherImages",
        OtherKey="ImageId",
        DeleteRule="NO ACTION")]
    public EntitySet<OtherImage> OtherImages{
        ...
    }
