    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    
    				
    public class Program
    {
    	public static void Main()
    	{
    		string json=@"{'result':{'task':{'id':'1163','parentId':null,'title':'qwe','description':'','mark':null,'priority':'1','status':'2','multitask':'N','notViewed':'N','replicate':'N','groupId':'0','stageId':'0','createdBy':'1','createdDate':'2020-01-08T10:43:45+03:00','responsibleId':'1','changedBy':'1','changedDate':'2020-01-08T10:43:45+03:00','statusChangedBy':'1','statusChangedDate':'2020-01-08T10:43:45+03:00','closedBy':null,'closedDate':null,'dateStart':null,'deadline':null,'startDatePlan':null,'endDatePlan':null,'guid':'{4b4a2708-36b4-4e81-b422-2c07d28de266}','xmlId':null,'commentsCount':null,'allowChangeDeadline':'Y','taskControl':'N','addInReport':'N','forkedByTemplateId':null,'timeEstimate':'0','timeSpentInLogs':null,'matchWorkTime':'N','forumTopicId':null,'forumId':null,'siteId':'s1','subordinate':'N','favorite':'N','exchangeModified':null,'exchangeId':null,'outlookVersion':'1','viewedDate':'2020-01-08T10:43:46+03:00','sorting':'21504.2500000','durationPlan':null,'durationFact':null,'durationType':'days','descriptionInBbcode':'Y','ufCrmTask':false,'ufTaskWebdavFiles':[],'ufMailMessage':null,'auditors':[],'accomplices':[],'checklist':[],'group':[],'creator':{'id':'1','name':'??????? ????','link':'/company/personal/user/1/','icon':'/bitrix/images/tasks/default_avatar.png'},'responsible':{'id':'1','name':'??????? ????','link':'/company/personal/user/1/','icon':'/bitrix/images/tasks/default_avatar.png'},'action':{'accept':false,'decline':false,'complete':true,'approve':false,'disapprove':false,'start':true,'pause':false,'delegate':true,'remove':true,'edit':true,'defer':true,'renew':false,'create':false,'changeDeadline':true,'checklistAddItems':true,'addFavorite':true,'deleteFavorite':false,'edit.originator':true,'checklist.reorder':true,'elapsedtime.add':true,'dayplan.timer.toggle':false,'edit.plan':true,'checklist.add':true,'favorite.add':true,'favorite.delete':false}}},'time':{'start':1578473027.682132,'finish':1578473027.950497,'duration':0.26836490631103516,'processing':0.018194198608398438,'date_start':'2020-01-08T11:43:47+03:00','date_finish':'2020-01-08T11:43:47+03:00'}}";
    		var Sresponse = JsonConvert.DeserializeObject<RootObject>(json);
    		Console.WriteLine(Sresponse.result.task.changedBy);
    		Console.WriteLine(Sresponse.result.task.descriptionInBbcode);
    		Console.WriteLine(Sresponse.result.task.multitask);
    
    	}
    }
    
    public class Creator
    {
        public string id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public string icon { get; set; }
    }
    
    public class Responsible
    {
        public string id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public string icon { get; set; }
    }
    
    public class Action
    {
        public bool accept { get; set; }
        public bool decline { get; set; }
        public bool complete { get; set; }
        public bool approve { get; set; }
        public bool disapprove { get; set; }
        public bool start { get; set; }
        public bool pause { get; set; }
        public bool @delegate { get; set; }
        public bool remove { get; set; }
        public bool edit { get; set; }
        public bool defer { get; set; }
        public bool renew { get; set; }
        public bool create { get; set; }
        public bool changeDeadline { get; set; }
        public bool checklistAddItems { get; set; }
        public bool addFavorite { get; set; }
        public bool deleteFavorite { get; set; }
    	[JsonProperty("edit.originator")]
        public bool editoriginator { get; set; }
    	[JsonProperty("checklist.reorder")]
        public bool checklistreorder { get; set; }
    	[JsonProperty("elapsedtime.add")]
        public bool elapsedtimeadd { get; set; }
    	[JsonProperty("dayplan.timer.toggle")]
        public bool dayplantimertoggle { get; set; }
    	[JsonProperty("edit.plan")]
        public bool editplan { get; set; }
    	[JsonProperty("checklist.add")]
        public bool checklistadd { get; set; }
    	[JsonProperty("favorite.add")]
        public bool favoriteadd { get; set; }
    	[JsonProperty("favorite.delete")]
        public bool favoritedelete { get; set; }
    }
    
    public class Task
    {
        public string id { get; set; }
        public object parentId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public object mark { get; set; }
        public string priority { get; set; }
        public string status { get; set; }
        public string multitask { get; set; }
        public string notViewed { get; set; }
        public string replicate { get; set; }
        public string groupId { get; set; }
        public string stageId { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public string responsibleId { get; set; }
        public string changedBy { get; set; }
        public DateTime changedDate { get; set; }
        public string statusChangedBy { get; set; }
        public DateTime statusChangedDate { get; set; }
        public object closedBy { get; set; }
        public object closedDate { get; set; }
        public object dateStart { get; set; }
        public object deadline { get; set; }
        public object startDatePlan { get; set; }
        public object endDatePlan { get; set; }
        public string guid { get; set; }
        public object xmlId { get; set; }
        public object commentsCount { get; set; }
        public string allowChangeDeadline { get; set; }
        public string taskControl { get; set; }
        public string addInReport { get; set; }
        public object forkedByTemplateId { get; set; }
        public string timeEstimate { get; set; }
        public object timeSpentInLogs { get; set; }
        public string matchWorkTime { get; set; }
        public object forumTopicId { get; set; }
        public object forumId { get; set; }
        public string siteId { get; set; }
        public string subordinate { get; set; }
        public string favorite { get; set; }
        public object exchangeModified { get; set; }
        public object exchangeId { get; set; }
        public string outlookVersion { get; set; }
        public DateTime viewedDate { get; set; }
        public string sorting { get; set; }
        public object durationPlan { get; set; }
        public object durationFact { get; set; }
        public string durationType { get; set; }
        public string descriptionInBbcode { get; set; }
        [JsonConverter(typeof(SingleOrArrayConverter<bool>))]
    	public List<bool> ufCrmTask { get; set; }
        public List<object> ufTaskWebdavFiles { get; set; }
        public object ufMailMessage { get; set; }
        public List<object> auditors { get; set; }
        public List<object> accomplices { get; set; }
        public List<object> checklist { get; set; }
        public List<object> group { get; set; }
        public Creator creator { get; set; }
        public Responsible responsible { get; set; }
        public Action action { get; set; }
    }
    
    public class Result
    {
        public Task task { get; set; }
    }
    
    public class Time
    {
        public double start { get; set; }
        public double finish { get; set; }
        public double duration { get; set; }
        public double processing { get; set; }
        public DateTime date_start { get; set; }
        public DateTime date_finish { get; set; }
    }
    
    public class RootObject
    {
        public Result result { get; set; }
        public Time time { get; set; }
    }
    
    //Custom converter to handle single type or array type
    class SingleOrArrayConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<T>));
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                return token.ToObject<List<T>>();
            }
            return new List<T> { token.ToObject<T>() };
        }
    
        public override bool CanWrite
        {
            get { return false; }
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    
