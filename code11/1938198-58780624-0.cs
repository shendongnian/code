    public void ShouldOpenMachO()
        {
            var fileName = Utilities.GetBinary("simple-mach-o");
            ELFSharp.MachO.MachO machO;
            Assert.AreEqual(MachOResult.OK, MachOReader.TryLoad(fileName, out machO));
        }
