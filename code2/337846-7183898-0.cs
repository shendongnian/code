    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.Objects.DataClasses;
    using System.Runtime.Serialization;
    [assembly: EdmSchemaAttribute()]
    namespace DtcInvoicerDbModel
    {
        [EdmEntityType(NamespaceName="DtcInvoicerDbModel", Name="Employee")]
        [DataContract(IsReference=true)]
        public class Employee
        {
            [DataMember]
            [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false)]
            public int ID { get; set; }
            [DataMember]
            [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
            public bool IsActive { get; set; }
            [DataMember]
            [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
            public string FirstName { get; set; }
            [DataMember]
            [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
            public string LastName { get; set; }
            [DataMember]
            [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
            public string Username { get; set; }
            [DataMember]
            [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false)]
            public string Password { get; set; }
            [DataMember]
            [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true)]
            public DateTime? EmployeeSince { get; set; }
        }
    }
