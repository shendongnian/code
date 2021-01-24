csharp
using System;
using System.Linq;
using MongoDB.Entities;
using MongoDB.Driver.Linq;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace StackOverflow
{
    public class Form : Entity
    {
        public DateTime? DateDeleted { get; set; }
        public string ParentFormKeyID { get; set; }
        public Data[] FormFieldsData { get; set; }
    }
    public class Data
    {
        public string ID { get; set; }
        public DateTime? DateDeleted { get; set; }
        public string PlaceOfPatientRegistraiton { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal ActualCost { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new DB("test");
            var form = new Form
            {
                DateDeleted = null,
                ParentFormKeyID = "xxx",
                FormFieldsData = new[] {
                    new Data{ ID="aaa", ActualCost = 10.10m, DateDeleted = null, PlaceOfPatientRegistraiton = "Batumi" },
                    new Data{ ID="bbb", ActualCost = 20.20m, DateDeleted = null, PlaceOfPatientRegistraiton = "Batumi" },
                    new Data{ ID="ccc", ActualCost = 30.30m, DateDeleted = null, PlaceOfPatientRegistraiton = "Batumi" }
                }
            };
            form.Save();
            var res = DB.Collection<Form>()
                        .Where(f => f.DateDeleted == null && f.ParentFormKeyID == "xxx")
                        .SelectMany(d => d.FormFieldsData)
                        .Where(d => d.PlaceOfPatientRegistraiton == "Batumi")
                        .GroupBy(d => d.PlaceOfPatientRegistraiton)
                        .Select(g => new
                        {
                            Place = g.Key,
                            Total = g.Sum(d => d.ActualCost),
                            Minimum = g.Min(d => d.ActualCost),
                            Maximum = g.Max(d => d.ActualCost),
                            Average = g.Average(d => d.ActualCost)
                        }).First();
        }
    }
}
here's the aggregation pipeline it generates:
javascript
[{
    "$match": {
        "DateDeleted": null,
        "ParentFormKeyID": "xxx"
    }
}, {
    "$unwind": "$FormFieldsData"
}, {
    "$project": {
        "FormFieldsData": "$FormFieldsData",
        "_id": 0
    }
}, {
    "$match": {
        "FormFieldsData.PlaceOfPatientRegistraiton": "Batumi"
    }
}, {
    "$group": {
        "_id": "$FormFieldsData.PlaceOfPatientRegistraiton",
        "__agg0": {
            "$sum": "$FormFieldsData.ActualCost"
        },
        "__agg1": {
            "$min": "$FormFieldsData.ActualCost"
        },
        "__agg2": {
            "$max": "$FormFieldsData.ActualCost"
        },
        "__agg3": {
            "$avg": "$FormFieldsData.ActualCost"
        }
    }
}, {
    "$project": {
        "Place": "$_id",
        "Total": "$__agg0",
        "Minimum": "$__agg1",
        "Maximum": "$__agg2",
        "Average": "$__agg3",
        "_id": 0
    }
}]
