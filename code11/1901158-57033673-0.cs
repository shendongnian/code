    public class localSpriteSlice : MonoBehaviour
    {
        public SpriteRenderer spriteSliceSize;
    
        void Update()
        {
            //increase height of sprite and retain slice proportions
            spriteSliceSize.size += new Vector2(0, 0.1f);
        }
    }
