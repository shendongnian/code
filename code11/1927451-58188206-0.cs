private async Task UpdateCourseTrainers(Course courseInputEntity, Course savedCourse)
{            
   var toRemove = savedCourse.CourseTrainers.Except(courseInputEntity.CourseTrainers).ToList();          
   await _courseTrainerRepository.DeleteAsync(ct => toRemove.Any(t => t.TrainerId == ct.TrainerId));
   var toInsert = courseInputEntity.CourseTrainers.Except(savedCourse.CourseTrainers).ToList();
   foreach (var trainer in toInsert)
   {
      await _courseTrainerRepository.InsertAsync(trainer);
   }
}
And then in the CourseTrainer class I implemented IEquatable<CourseTrainer>
and added the following code to allow the Except above to work
public bool Equals(CourseTrainer other)
{
   if (ReferenceEquals(other, null))
   {
      return false;
   }
   if (ReferenceEquals(this, other))
   {
      return true;
   }
   return CourseId.Equals(other.CourseId) && TrainerId.Equals(other.TrainerId);
}
public override int GetHashCode()
{
   int hashCourseId = CourseId.GetHashCode();
   int hashTrainerId = TrainerId.GetHashCode();
   return  hashCourseId ^ hashTrainerId;
}
