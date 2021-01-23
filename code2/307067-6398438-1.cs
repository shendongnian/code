    public class PItem
    {
      public String content;
      public int count;
      public int fee;
      public int amount;
      public String description;
      // default values
      public PItem(): this("", 0, 0, "", 0) {}
      public PItem(String _content): this (_content, 0, 0, "", 0) {}
      public PItem(String _content, int _count): this(_content, _count, 0, "", 0) {}
      public PItem(String _content, int _count, int _fee): this(_content, _count, _fee, "", 0) {}
      public PItem(String _content, int _count, int _fee, string _description): this(_content, _count, _fee, _description, 0) {}
      public PItem(String _content, int _count, int _fee, string _description, int _amount)
      {
          content = _content;
          count = _count < 0 ? 0 : _count;
          fee = _fee;
          description = _description;
          amount = _amount < 0 ? 0 : _amount;
      }
    }
