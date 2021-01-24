    public class BulletUndoManager : MonoBehaviour {
        #region Singleton
        private static BulletUndoManager instance;
    
        public static BulletUndoManager Instance {
            get => instance;
        }
        #endregion
    
        private struct DeletedBulletInfo {
            public BulletInfo BulletInfo { get; private set; }
            public Vector3 LastPosition { get; private set; }
            public DeletedBulletInfo(BulletInfo bulletInfo, Vector3 lastPosition) {
                BulletInfo = bulletInfo;
                LastPosition = lastPosition;
            }
        }
    
        Stack<DeletedBulletInfo> lastDeletedBullet;
    
        [SerializeField, Tooltip("The prefab of the bullet")]
        private Bullet bulletPrefab;
    
        private void Awake() {
            instance = this;
        }
    
        public void UndoBulletDeletion() {
            if (lastDeletedBullet.Count > 0) {
                DeletedBulletInfo lastDeletedBulletInfo = lastDeletedBullet.Pop();
    
                var newBullet = Instantiate(bulletPrefab);
    
                newBullet.InitalizeBullet(lastDeletedBulletInfo.BulletInfo);
                newBullet.transform.position = lastDeletedBulletInfo.LastPosition;
            }
        }
    
        public void AddDeletedBulletInfo(BulletInfo bulletInfo, Vector3 bulletLastPosition) {
            lastDeletedBullet.Push(new DeletedBulletInfo(bulletInfo, bulletLastPosition));
        }
    }
