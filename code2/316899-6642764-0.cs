    <set cascade="all-delete-orphan" inverse="true" name="Media">
      <key>
        <column name="Media_id" />
      </key>
      <one-to-many class="MediaItem" />
    </set>
    using Iesi.Collections.Generic;
    
    public Media()
    {
        this.Media = new HashedSet<MediaItem>();
    }
    public virtual ISet<MediaItem> Media { get; set; }
