    using System.IO;
    public interface ISettings
    {
      /// <summary>
      /// Will be called after you Setup has executed if it returns True for a save to be performed. You are given a Stream to write your data to.
      /// </summary>
      /// <param name="s"></param>
      /// <remarks></remarks>
      void Save(Stream s);
      /// <summary>
      /// Will be called before your Setup Method is to enable the loading of existing settings. If there is no previous configuration this method will NOT be called
      /// </summary>
      /// <param name="s"></param>
      /// <remarks></remarks>
      void Load(Stream s);
      /// <summary>
      /// Your plugin must setup a GUID that is unique for your project. The Main Program will check this and if it is duplicated your DLL will not load
      /// </summary>
      /// <value></value>
      /// <returns></returns>
      /// <remarks></remarks>
      Guid Identifier { get; }
      /// <summary>
      /// This Description will be displayed for the user to select your Plugin. You should make this descriptive so the correct one is selected in the event they have multiple plugins active.
      /// </summary>
      /// <value></value>
      /// <returns></returns>
      /// <remarks></remarks>
      string Description { get; }
    }
