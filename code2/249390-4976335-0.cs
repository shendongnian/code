    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    
    namespace ConsoleApplication5
    {
      class Program
      {
        static void Main(string[] args)
        {
          var posts = GetPosts1();
          foreach (var post in posts)
          {
            Console.WriteLine(post.PostId);
            Console.WriteLine(post.PostTitle);
            Console.WriteLine(post.PostSlug);
            Console.WriteLine(post.PostDate);
          }
        }
    
        static IEnumerable<PostDtw> GetPosts1()
        {
          DataTable postsDt = GetPostsDataTable();
          PostDtw postDtw = new PostDtw();
    
          foreach(DataRow row in postsDt.Rows)
          {
            postDtw.DataRow = row;
            yield return postDtw;
          }        
        }
    
        static IEnumerable<PostDtw> GetPosts2()
        {
          DataTable postsDt = GetPostsDataTable();
          foreach (DataRow row in postsDt.Rows)
            yield return new PostDtw(row);
        }
    
        static DataTable GetPostsDataTable()
        {
          throw new NotImplementedException();
        }
      }
    
      /// <summary>
      ///This is the Base Class for all DataTable Wrappers
      /// </summary>
      public class BaseDataTableWrapper
      {
        public DataRow DataRow { get; set; }
    
        public BaseDataTableWrapper()
        {
        }
    
        public BaseDataTableWrapper(DataRow row)
          : this()
        {
          DataRow = row;
        }
      }
    
      #region [GetPost]
    
      /// <summary>
      ///This class is a wrapper around a DataTable,
      ///Associated with the stored procedure - GetPost
      ///This class provides a strongly typed interface to access data from the DataTable
      ///containing the result of the given stored procedure.
      /// </summary>
      public sealed class PostDtw : BaseDataTableWrapper
      {
        public Int32 PostId { get { return (Int32)DataRow[0]; } set { DataRow[0] = value; } }
        public DateTime PostDate { get { return (DateTime)DataRow[1]; } set { DataRow[1] = value; } }
        public String PostSlug { get { return (String)DataRow[2]; } set { DataRow[2] = value; } }
        public Int32 UserId { get { return (Int32)DataRow[3]; } set { DataRow[3] = value; } }
        public String PostTitle { get { return (String)DataRow[4]; } set { DataRow[4] = value; } }
        public String PostText { get { return (String)DataRow[5]; } set { DataRow[5] = value; } }
        public Boolean PostIsPublished { get { return (Boolean)DataRow[6]; } set { DataRow[6] = value; } }
        public Boolean PostIsPublic { get { return (Boolean)DataRow[7]; } set { DataRow[7] = value; } }
        public String PostTitleImg { get { if (DataRow[8] != DBNull.Value) return (String)DataRow[8]; else return default(String); } set { DataRow[8] = value; } }
    
        public PostDtw()
          : base()
        {
        }
    
        public PostDtw(DataRow row)
          : base(row)
        {
        }
      }
    
      #endregion [GetPost]
    
    }
