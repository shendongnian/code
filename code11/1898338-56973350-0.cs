C#
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
namespace legacy
{
    public class FloatLicManager3
    {
        public static int TestExport(int left, int right)
        {
            return left + right;
        }
    }
}
Building it with:
shell
dotnet build --runtime linux-x64
And using as:
python
import os
import clr
scriptDirectory = os.path.dirname(os.path.abspath(__file__))
cSharp = os.path.join(scriptDirectory, "legacy/bin/Debug/netstandard2.0/linux-x64/legacy.dll")
clr.AddReference(cSharp)
from legacy import FloatLicManager3
testing = FloatLicManager3()
testing.TestExport(1, 2)
