    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                GetUserReq userReq = new GetUserReq();
                userReq.Envelope = new Envelope();
                GetUserResponse userResponse = new GetUserResponse();
                userResponse.Envelope = new Envelope();
                userReq.Body = new Body();
                userReq.Body.GetUser = new GetUser();
                userReq.Body.GetUser.ReturnedTags = new ReturnedTags();
                Boolean allReturnTags = true;
                if (allReturnTags)
                {
                    userReq.Body.GetUser.ReturnedTags.AssociatedGroups = new AssociatedGroups();
                    userReq.Body.GetUser.ReturnedTags.AssociatedDevices = new AssociatedDevices();
                    userReq.Body.GetUser.ReturnedTags.AssociatedGroups.UserGroup = new UserGroup() { Name = "", UserRoles = new UserRoles() };
                    userReq.Body.GetUser.ReturnedTags.AssociatedGroups.UserGroup.UserRoles = new UserRoles() { UserRole = "" };
                }
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(FILENAME, settings);
                XmlSerializer serializer = new XmlSerializer(typeof(GetUserReq));
                serializer.Serialize(writer, userReq);
            }
        }
        [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public class Body
        {
            [XmlElement(ElementName = "getUser", Namespace = "http://www.cisco.com/AXL/API/9.1")]
            public GetUser GetUser { get; set; }
        }
        public class GetUser
        {
            public ReturnedTags ReturnedTags { get; set; }
        }
        public class ReturnedTags
        {
            public AssociatedGroups AssociatedGroups { get; set; }
            public AssociatedDevices AssociatedDevices { get; set; }
        }
        public class GetUserReq
        {
            public Envelope Envelope { get; set; }
            public Body Body { get; set; }
        }
        public class GetUserResponse
        {
            public Envelope Envelope { get; set; }
        }
        [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public class Envelope
        {
            [XmlElement(ElementName = "Header", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
            public string Header { get; set; }
            [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
            public Body Body { get; set; }
            [XmlAttribute(AttributeName = "soapenv", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Soapenv { get; set; }
            [XmlAttribute(AttributeName = "ns", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Ns { get; set; }
        }
        public class AssociatedGroups
        {
            public UserGroup UserGroup { get; set; }
        }
        public class AssociatedDevices
        {
        }
        public class UserGroup
        {
            public UserRoles UserRoles { get; set; }
            public string Name { get; set; }
        }
        public class UserRoles
        {
            public string UserRole { get; set; }
        }
    }
