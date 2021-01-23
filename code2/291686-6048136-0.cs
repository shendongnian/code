    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using omg.org.CosNaming;
    using Ch.Elca.Iiop;
    using Ch.Elca.Iiop.Services;
    using System.Runtime.Remoting.Channels;
    using Ch.Elca.Iiop.Idl;
    [RepositoryID("IDL:LicenseInfo:1.0")]
    public interface ILicenseInfo
    {
        Int32 GetHardwareKey([IdlSequence(0)] out byte[] hwKey);
        Int32 GetInstallationNumberList([IdlSequence(0)] out byte[] instNum);
    }
    class Program
    {
        static void Main(string[] args)
        {
            IiopClientChannel channel = new IiopClientChannel();
            ChannelServices.RegisterChannel(channel, false);
            CorbaInit init = CorbaInit.GetInit();
            NamingContext context = init.GetNameService("MYLICSRV", 30000);
            NameComponent[] names = new NameComponent[] { new NameComponent("B1LicenseInfo") };
            ILicenseInfo li = (ILicenseInfo)context.resolve(names);
            byte[] hwKey;
            byte[] instNum;
            li.GetHardwareKey(out hwKey);
            li.GetInstallationNumberList(out instNum);
            Encoding encoding = new System.Text.UnicodeEncoding(false, false, true);
            Console.WriteLine(encoding.GetString(hwKey));
            Console.WriteLine(encoding.GetString(instNum));
        }
    }
