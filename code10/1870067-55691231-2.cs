        public async Task<ReturnResult> DeleteUser(DeleteDto deleteDto, CancellationToken cancellationToken)
        {
            using (var db = new Db())
            using (var tran = db.Database.BeginTransaction())
            {
                await db.Database.ExecuteSqlCommandAsync("delete from UserRole where UserId = @id", cancellationToken, deleteDto.id);
                await db.Database.ExecuteSqlCommandAsync("delete from User where UserId = @id", cancellationToken, deleteDto.id);
                tran.Commit();
            }
            return Ok();
        }
