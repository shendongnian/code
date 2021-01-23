    public class ProcessStartInfoCreator {
        public static ProcessStartInfo Create() {
            return new ProcessStartInfo {
                FileName = "some.exe",
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = false  // <--- BUG
            };
        }
    }
    [Test]
    public void TestThatFindsBug() {
        var psi = ProcessStartInfoCreator.Create();
        Assert.That(psi.RedirectStandardOutput, Is.True);
    }
